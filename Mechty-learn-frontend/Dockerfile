FROM node:20.13.1
WORKDIR /app
ENV DOTNET_BACKEND_URL=${DOTNET_BACKEND_URL}
COPY package.json package-lock.json ./
RUN npm install
COPY . .
RUN npm run build
EXPOSE 5000
CMD [ "npm", "run", "dev", "--", "--host", "0.0.0.0" ]