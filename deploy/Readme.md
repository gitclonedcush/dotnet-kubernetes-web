## Usage

* Modify the docker image in the deployment file.
* Apply via `kubectl apply -f .`

## Best Practices

* Consider using https://github.com/bitnami-labs/sealed-secrets. You should not check in regular kubernetes secrets into your repository.
* Always have resource limits on your deployments and pods.
* Specify the latest stable api version in config files.
* You can group similar items into a single yaml and divide them using `---`. I've seperated them here to exemplify the different components.
* You can create all components in this directory by using `kubectl apply -f .`