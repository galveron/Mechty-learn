FROM node:20.13.1
ARG VITE_APP_TITLE
ENV VITE_APP_TITLE=$VITE_APP_TITLE
EXPOSE 4173
WORKDIR /app
COPY . .
RUN npm install
RUN npm run build
CMD [ "npm", "run", "preview", "--", "--host", "0.0.0.0" ]