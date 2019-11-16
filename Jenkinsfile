pipeline {
    agent { docker 'mcr.microsoft.com/dotnet/core/sdk:3.0' }
	
	environment {
		PROJECT      = './Booth.Common/Booth.Common.csproj'
        TEST_PROJECT = './Booth.Common.Tests/Booth.Common.Tests.csproj'
    }

    stages {
	    stage('Test') {
			steps {
				sh 'mkdir ./test'
				sh "dotnet test ${TEST_PROJECT} --configuration Release --output ./test --logger trx --results-directory ./result"
            }
			post {
				always {
					xunit (
						thresholds: [ skipped(failureThreshold: '0'), failed(failureThreshold: '0') ],
						tools: [ MSTest(pattern: 'result/*.trx') ]
						)
				}
			}
        }
        stage('Build') {
			steps {
				sh 'mkdir ./app'
				sh "dotnet pack ${PROJECT} --configuration Release --output ./app"
            }
		}
    }
	
	post {
		always {
			cleanWs()
		}
	}
}