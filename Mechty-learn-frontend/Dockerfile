FROM node:20.13.1
WORKDIR /app
ENV RENDER_BACKEDN_URL=${RENDER_BACKEDN_URL}
COPY package.json package-lock.json ./
RUN npm install
COPY . .
RUN npm run build
EXPOSE 5000
CMD [ "npm", "run", "preview", "--", "--host", "0.0.0.0" ]