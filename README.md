# dotnet-kubernetes-web 

dotnet-kubernetes-web is a simple `dotnet new` template to automate the process of setting up a simple dotnet core service, with a Dockerfile and sample Kubernetes deployment files.

## Project Architecture

* `src` contains main asp.net core service based on `dotnet new webapi` and named according to `dotnet new k8sapp -n myAppName`.
* * By default this asp.net core service comes with [AppMetrics](https://www.app-metrics.io/) for `/health` and `/metrics` endpoints.
* `tests` contains one testing project for your asp.net core service based on `dotnet new xunit`
* A working Dockerfile is supplied, that can be expanded if needed.
* `deploy` contains a set of Kubernetes deployment files that can be used as a template for deploying to a kubernetes cluster. 
* * You must add the docker image and repository to the deployment.yaml file.

## Installation

## Usage
* To create a new asp.net core with kubernetes app run `dotnet new k8sapp -n myAppName`