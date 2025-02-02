# Dashboard

A real-time dashboard that displays the latest image events and their statistics, powered by Angular and AWS serverless services.

![Dashboard Preview](screenshot.png) <!-- Add a screenshot if available -->

## Features

- 🕒 Auto-refreshes data every 5 seconds
- 🖼️ Displays latest image with description and timestamp
- 📊 Shows event count from the last hour
- 🚦 Error handling and loading states
- 📱 Responsive design with Angular Material
- ☁️ Integrates with AWS API Gateway and Lambda

## Prerequisites

- Node.js v18+ [Download](https://nodejs.org/)
- npm v9+ or yarn
- Angular CLI v17+
- AWS account with API Gateway endpoint

## Installation

1. Clone the repository:

```bash
git clone 'repo'
cd 'repo'
```

2. Install dependencies:

```bash
npm install
```

3. Configuration:

Set your API Gateway endpoint in environment.ts :

```
export const environment = {
  production: false,
  apiUrl: 'https://your-api-id.execute-api.region.amazonaws.com/Dev'
};
```

4. Running Locally:

```bash
ng serve
```

## Deployment to AWS

1. Build production bundle:

```bash
ng build --configuration production
```

2. Deploy to S3:

```bash
aws s3 sync dist/image-ui s3://your-bucket-name --delete
```

## Project Structure

```
src/app/
├── dashboard/ # Main dashboard component
│ ├── dashboard.component.ts
│ ├── dashboard.component.html
│ └── dashboard.component.scss
├── services/
│ └── api.service.ts # API communication service
├── environments/ # Environment configurations
├── assets/ # Static assets
└── app.component.ts # Root component
```
