FROM node:stretch-slim AS build-env
WORKDIR /app

# Install
COPY . ./
RUN npm install

# Build
ARG env=prod
RUN npm rebuild node-sass \
    && npm run build:${env}

# Build runtime image
FROM nginx:stable
WORKDIR /usr/share/nginx/html
COPY --from=build-env /app/nginx.conf /etc/nginx/conf.d/default.conf
COPY --from=build-env /app/dist ./
EXPOSE 80
