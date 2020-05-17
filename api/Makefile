PROJECT_ID=tacoron
GCP_REGION=asia-northeast1

format:
	go fmt
deploy-hello-world:
	gcloud functions deploy HelloHTTP --runtime go113 --trigger-http --allow-unauthenticated --region "${GCP_REGION}" --project "${PROJECT_ID}" --set-env-vars PROJECT_ID="${PROJECT_ID}"
gcloud-login:
	gcloud auth login
gcloud-default-login:
	gcloud auth application-default login
