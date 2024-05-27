FROM node:20.13.1
ARG VITE_APP_TITLE
ARG BACKEND_URL
ENV VITE_APP_TITLE=$VITE_APP_TITLE
ENV BACKEND_URL=${BACKEND_URL}
EXPOSE 4173
WORKDIR /app
COPY . .
RUN npm install
RUN npm run build
CMD [ "npm", "run", "preview", "--", "--host", "0.0.0.0" ]