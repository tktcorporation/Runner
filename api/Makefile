PROJECT_ID=tacoron
GCP_REGION=asia-northeast1

format:
	go fmt
deploy-store-score:
	gcloud functions deploy StoreScoreHTTP --runtime go113 --trigger-http --allow-unauthenticated --region "${GCP_REGION}" --project "${PROJECT_ID}" --set-env-vars PROJECT_ID="${PROJECT_ID}"
deploy-read-score:
	gcloud functions deploy ReadScoreHTTP --runtime go113 --trigger-http --allow-unauthenticated --region "${GCP_REGION}" --project "${PROJECT_ID}" --set-env-vars PROJECT_ID="${PROJECT_ID}"
gcloud-login:
	gcloud auth login
gcloud-default-login:
	gcloud auth application-default login
test:
	go test ./...
