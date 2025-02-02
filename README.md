# wecheer.io
Fullstack Team Lead position at Wecheer
# AWS Serverless Image Processing Application

A serverless application built with .NET 8 Lambda and Angular that processes and displays image events. The application receives image events through both an API Gateway endpoint and optionally through a Kinesis stream.

## Features

- Serverless backend using .NET 8 Lambda
- REST API exposed through AWS API Gateway
- Real-time image display with Angular Material UI
- In-memory event tracking with hourly statistics
- Optional Kinesis stream integration
- Full CloudFormation template for easy deployment

## System Architecture

### Backend (.NET 8 Lambda)
- Processes incoming image events
- Maintains in-memory event tracking
- Exposes REST API endpoints:
  - POST `/api/images` - Submit new image events
  - GET `/api/images/latest` - Retrieve latest image
  - GET `/api/images/count` - Retrieve statistics for the last 1h
- Swagger UI documentation available

### Frontend (Angular)
- Material Design UI components
- Auto-refreshing display (5-second intervals)
- Shows latest image with description
- Displays event count for the last hour

### Event Format
```json
{
  "imageUrl": "http://...",
  "description": "This is a great image"
}
```

## Prerequisites

- AWS Account
- .NET 8 SDK
- Node.js and npm
- AWS CLI (configured with appropriate credentials)
- Angular CLI

## Local Development

1. Clone the repository:
```bash
git clone <repository-url>
cd <repository-name>
```

2. Backend setup:
```bash
cd src/ImageProcessor
dotnet restore
dotnet build
```

3. Frontend setup:
```bash
cd src/Frontend
npm install
ng serve
```

## Deployment

### Backend Deployment

1. Deploy using AWS CloudFormation:
```bash
dotnet lambda deploy-serverless
```

2. Note the API Gateway URL from the CloudFormation outputs

### Frontend Deployment

1. Update the API URL in `environment.ts`:
```typescript
export const environment = {
  production: true,
  apiUrl: 'YOUR_API_GATEWAY_URL'
};
```

2. Build and deploy:
```bash
ng build --prod
# Deploy the dist folder to your hosting service
```

## Kinesis Stream Integration (Optional)

To enable Kinesis stream processing:

1. Create a Kinesis stream in your AWS account
2. Pass the stream ARN during CloudFormation deployment:
```bash
dotnet lambda deploy-serverless --template-parameters KinesisStreamArn=<your-stream-arn>
```

## API Documentation

The API documentation is available through Swagger UI at:
```
https://<your-api-gateway-url>/swagger
```

## Project Structure

```
├── src/
│   ├── wecheer.api/          # .NET 8 api hosted as Lambda function
│   ├── wecheer.core/         # .NET 8 core library as application layer
│   ├── wecheer.stream/       # .NET 8 Kinesis consumer hosted as Lambda function
│   ├── frontend/             # Angular frontend application
│   └── Infrastructure/       # CloudFormation templates
├── tests/                    # Test projects
└── README.md
```

## Live Demo

- API Gateway URL: https://oxsbprqxw4.execute-api.eu-north-1.amazonaws.com/Prod/index.html
- Frontend URL: http://wecheer.frontend.s3-website.eu-north-1.amazonaws.com/index.html

## Contributing

1. Fork the repository
2. Create your feature branch (`git checkout -b feature/AmazingFeature`)
3. Commit your changes (`git commit -m 'Add some AmazingFeature'`)
4. Push to the branch (`git push origin feature/AmazingFeature`)
5. Open a Pull Request

## License

This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.
