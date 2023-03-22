kubectl apply -f ./k8s/redis/deployment.yml

exit

kubectl get pods -l app=redis-cluster -o jsonpath='{range.items[*]}{.status.podIP}:6379'
echo "..."
kubectl get svc redis-cluster
echo "..."

redis-cli -c -h <redis-cluster-service-ip> -p 6379
