import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, catchError, interval, map, switchMap } from 'rxjs';

export interface ImageEvent {
  imageUrl: string;
  description: string;
  receivedTime: Date;
}

interface CountResponse {
  count: number;
}

@Injectable({ providedIn: 'root' })
export class ApiService {
  private readonly apiUrl =
    'https://oxsbprqxw4.execute-api.eu-north-1.amazonaws.com/Prod'; // Replace with your actual URL

  constructor(private http: HttpClient) {}

  getLatestImageEvent(): Observable<ImageEvent> {
    return interval(5000).pipe(
      switchMap(() =>
        this.http.get<ImageEvent>(`${this.apiUrl}/api/images/latest`)
      ),
      catchError((error) => {
        console.error('Error fetching latest image:', error);
        return [];
      })
    );
  }

  getHourlyCount(): Observable<number> {
    return interval(5000).pipe(
      switchMap(() =>
        this.http.get<CountResponse>(`${this.apiUrl}/api/images/count`)
      ),
      map((response) => response.count),
      catchError((error) => {
        console.error('Error fetching count:', error);
        return [];
      })
    );
  }
}
