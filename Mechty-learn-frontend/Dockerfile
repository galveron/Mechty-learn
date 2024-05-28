FROM node:20.13.1
ARG BACKEND_URL
ENV VITE_BACKEND_URL=${BACKEND_URL}
EXPOSE 4173
WORKDIR /app
COPY . .
RUN npm install
RUN npm run build
RUN echo "backend-url"
RUN echo ${VITE_BACKEND_URL}
CMD [ "npm", "run", "preview", "--", "--host", "0.0.0.0" ]