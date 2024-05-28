FROM node:20.13.1
ARG BACKEND_URL
ENV VITE_BACKEND_URL=${BACKEND_URL}
EXPOSE 4173
WORKDIR /app
COPY . .
RUN npm install
RUN npm run build
CMD [ "npm", "run", "preview", "--", "--host", "0.0.0.0" ]