## [1] Obraz bazowy
FROM php:8.1-apache
## [2] Inne składniki wymagane do działania aplikacji

COPY ./rest_api /var/www/html

RUN apt-get update
RUN apt-get install -y apache2
RUN a2enmod rewrite
RUN docker-php-ext-install mysqli
