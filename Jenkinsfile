pipeline {
		agent any

		environment {
            //git info
			gitRepository = 'http://gitlab.eztek.net/trueconnect/be/customersp.git'
			gitBranch = 'develop'
			gitlabCredential = 'gitlab_jenkin'

            // registry info
			dockerregistry = 'https://nexus.eztek.net'
			registryCredential = 'nexus_jenkin'

            //image info
			dockerimagename = "nexus.eztek.net/customer-sp/be"
    		dockerImage = ""
			version = "build-0.${BUILD_NUMBER}"
            dockerimage_tag = "nexus.eztek.net/${dockerimagename}"
		}

		stages {
			stage('Checkout project')
			{
			  steps
			  {
				git branch: gitBranch,
				   credentialsId: gitlabCredential,
				   url: gitRepository
				sh "git reset --hard"

			  }
			}
			stage('Build docker')
			{
			    agent any
			  steps
			  {
				script {
                        sh "echo ${dockerimage_tag}"
						dockerImage = docker.build dockerimagename
					}
			  }
			}
			stage('Pushing Image')
			{
      		  steps
			  {
        		script {
				//login registry
           		 docker.withRegistry( dockerregistry , registryCredential ) {
              	 //dockerImage.push(version)
				 dockerImage.push()
				 //sh "docker rmi ${dockerimage_tag}:${version} -f"
				 sh "docker rmi ${dockerimagename}:latest -f"
           		 }
          		}
        	  }
    	    }
			stage('Deploy')
			{
      		  steps
			  {
        		script {
          		  sh'ssh root@103.149.170.71 "docker-compose -f /var/www/html/Customer-sp/be/docker-compose.yml down "'
                  sh'ssh root@103.149.170.71 "docker rmi nexus.eztek.net/customer-sp/be"'
				  sh'ssh root@103.149.170.71 "docker-compose -f /var/www/html/Customer-sp/be/docker-compose.yml up -d"'
          		 }
          		}
        	  }
		}
	}
