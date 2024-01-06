FROM stripe/stripe-cli:v1.18.0

# If the base image uses yum
RUN yum update -y
RUN yum install bash -y

COPY ./entrypoint.sh /entrypoint.sh
RUN chmod +x /entrypoint.sh
ENTRYPOINT ["/entrypoint.sh"]