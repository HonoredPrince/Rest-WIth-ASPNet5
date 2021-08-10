FROM node:14.17.4
WORKDIR /app
COPY ["Client/.env", "Client/package-lock.json", "Client/package.json",  "./"]
RUN npm install --production
COPY . .
EXPOSE 80
CMD ["npm", "start"]