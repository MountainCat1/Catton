#!/bin/sh

stripe login

listen --forward-to http://host.docker.internal:3000/webhook

echo "XD"
