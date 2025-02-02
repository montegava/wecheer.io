import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, catchError, interval, map, switchMap } from 'rxjs';

export interface ImageEvent {
  imageUrl: string;
  description: string;
  receivedTime: Date;
}

export interface StatResponse {
  count: number;
  latestImage: ImageEvent;
}

@Injectable({ providedIn: 'root' })
export class ApiService {
  private readonly apiUrl =
    'https://oxsbprqxw4.execute-api.eu-north-1.amazonaws.com/Prod'; // Replace with your actual URL

  constructor(private http: HttpClient) {}

  getStats(): Observable<StatResponse> {
    return interval(5000).pipe(
      switchMap(() =>
        this.http.get<StatResponse>(`${this.apiUrl}/api/images/stats`)
      ),
      catchError((error) => {
        console.error('Error fetching count:', error);
        return [];
      })
    );
  }
}
