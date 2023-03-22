#!/bin/bash

echo "Deleting..."

kubectl delete -f redis-config-map.yaml
kubectl delete -f redis-sts.yaml
kubectl delete -f redis-service.yaml

kubectl delete -f redis-pv.yml

exit 0

sleep 3
echo "Creating..."

kubectl create namespace redis

kubectl apply -f redis-config-map.yaml
kubectl apply -f redis-sts.yaml
kubectl apply -f redis-service.yaml

echo "Creating persistent volume..."

kubectl apply -f redis-pv.yml