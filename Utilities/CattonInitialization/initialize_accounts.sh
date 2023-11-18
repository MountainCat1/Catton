curl https://localhost:5000/api/accounts -i --insecure -X POST -H "Content-Type: application/json" -d \
'{
  "email": "string@string.string",
  "username": "string",
  "password": "string"
}' 
curl https://localhost:5000/api/accounts -i --insecure -X POST -H "Content-Type: application/json" -d \
'{
  "email": "andrzej@a.a",
  "username": "andrzej",
  "password": "andrzej"
}' 
curl https://localhost:5000/api/accounts -i --insecure -X POST -H "Content-Type: application/json" -d \
'{
  "email": "kuba@a.a",
  "username": "kuba",
  "password": "kuba"
}' 



#curl -X POST -d @initializa_accounts.json http://localhost:8080/initialize_accounts

