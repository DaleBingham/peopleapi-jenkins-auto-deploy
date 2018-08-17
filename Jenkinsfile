def CONTAINER_NAME="people-api-pipeline"
def CONTAINER_TAG="latest"
def CONTAINER_DB_NAME="people-api-db-pipeline"
def CONTAINER_DB_TAG="latest"
def OPENSHIFT_PROJECT_NAME="people-api-pipeline"
def OPENSHIFT_IP="172.30.1.1:5000"

node {

    stage('Checkout') {
        checkout scm
    }

    stage("Compile Source and Scan"){
        try {
            bat "\"C:\\Program Files\\dotnet\\dotnet\" restore"
            bat "\"C:\\Program Files\\dotnet\\dotnet sonarscanner\" begin /k:\"peopleapi\" /d:sonar.login=\"1d62160d545c0bd72ec48737ba46219a9d0ea4bb\" /d:sonar.host.url=\"http://localhost:9000\""
            bat "\"C:\\Program Files\\dotnet\\dotnet\" build"
            bat "\"C:\\Program Files\\dotnet\\dotnet\" sonarscanner end /d:sonar.login=\"1d62160d545c0bd72ec48737ba46219a9d0ea4bb\""
        } catch(error){
            echo "The .NET Core 2.x compile failed with ${error}"
        }
    }

    stage("Image Prune"){
        imagePrune(CONTAINER_NAME)
        imagePrune(CONTAINER_DB_NAME)
    }

    stage('DB Image Build'){
        imageBuild(CONTAINER_DB_NAME, CONTAINER_DB_TAG, "database\\")
    }

    stage('Application Image Build'){
        imageBuild(CONTAINER_NAME, CONTAINER_TAG, ".")
    }

    stage('Push DB to OpenShift Registry'){
        withCredentials([usernamePassword(credentialsId: 'openshift-docker-registry-account', usernameVariable: 'USERNAME', passwordVariable: 'PASSWORD')]) {
            pushToImage(OPENSHIFT_IP,OPENSHIFT_PROJECT_NAME, CONTAINER_DB_NAME, CONTAINER_DB_TAG, USERNAME, PASSWORD)
        }
    }

    stage('Push App to OpenShift Registry'){
        withCredentials([usernamePassword(credentialsId: 'openshift-docker-registry-account', usernameVariable: 'USERNAME', passwordVariable: 'PASSWORD')]) {
            pushToImage(OPENSHIFT_IP,OPENSHIFT_PROJECT_NAME, CONTAINER_NAME, CONTAINER_TAG, USERNAME, PASSWORD)
        }
    }
}

def imagePrune(containerName){
    try {
        bat "\"C:\\Program Files\\Docker\\Docker\\Resources\\bin\\docker\" image prune -f"
        bat "\"C:\\Program Files\\Docker\\Docker\\Resources\\bin\\docker\" stop $containerName"
    } catch(error){}
}

def imageBuild(containerName, tag, pathToDockerfile){
    bat "\"C:\\Program Files\\Docker\\Docker\\Resources\\bin\\docker\" build -t $containerName:$tag --pull --no-cache $pathToDockerfile"
    echo "Image build complete"
}

def pushToImage(openshiftIP, projectName, containerName, tag, dockerUser, dockerPassword){
    bat "\"C:\\Program Files\\Docker\\Docker\\Resources\\bin\\docker\" login -u $dockerUser -p $dockerPassword $openshiftIP"
    bat "\"C:\\Program Files\\Docker\\Docker\\Resources\\bin\\docker\" tag $containerName:$tag $openshiftIP/$projectName/$containerName:$tag"
    bat "\"C:\\Program Files\\Docker\\Docker\\Resources\\bin\\docker\" push $openshiftIP/$projectName/$containerName:$tag"
    echo "Image push complete to OpenShift"
}
