PROJECT_NAME=tacoron
GCP_REGION=asia-northeast1

format:
	go fmt
deploy-hello-world:
	gcloud functions deploy HelloHTTP --runtime go113 --trigger-http --allow-unauthenticated --region "${GCP_REGION}" --project "${PROJECT_NAME}"
