# dotnet-kubernetes-web 

dotnet-kubernetes-web is a simple `dotnet new` template to automate the process of setting up a simple dotnet core service, with a Dockerfile and sample Kubernetes deployment files.

## Project Architecture

* `src` contains main asp.net core service based on `dotnet new webapi` and named according to `dotnet new k8sapp -n myAppName`.
  * By default this asp.net core service comes with [AppMetrics](https://www.app-metrics.io/) for `/health` and `/metrics` endpoints.
  * A `/info` endpoint is included for api version and service version information.
  * Serilog logging is also enabled by default. See: [Serilog](https://serilog.net/)
* `tests` contains one testing project for your asp.net core service based on `dotnet new xunit`
* A working Dockerfile is supplied, that can be expanded if needed.
* `deploy` contains a set of Kubernetes deployment files that can be used as a template for deploying to a kubernetes cluster. 
  * You must add the docker image and repository to the deployment.yaml file.

## Installation

* Run `dotnet new -i AspNetCore.Kubernetes.Template`

## Usage
* To create a new asp.net core with kubernetes app run `dotnet new k8sapp -n myAppName`

## Docker
The docker image will build without any changes to the repository. Most likely it will not need modification, even as you customize your
asp.net core service.

* To create a docker image run `cd src/myAppName/ && docker build -t myDockerImageName .`

## Kubernetes
Provided are kubernetes deployment template files. They require customization before they are ready to be deployed.

* Modify the configmap and secret files to contain any env vars specific to your asp.net core service.
* Modify the deployment file to point to your docker repository and image.
* Modify resource requests and limits.
