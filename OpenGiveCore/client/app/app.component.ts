import { Component } from '@angular/core';
import { Http } from '@angular/http';
import { MdSnackBar } from "@angular/material";

export interface WorkOrderRequest {
    title?: string;
    description?: string;
    latitude?: number;
    longitude?: number;
    requestorEmail?: string;
}

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
    
    workOrderRequest: WorkOrderRequest = {};
    constructor(private _http: Http, private _notifications: MdSnackBar) {
        if (navigator.geolocation) {
            navigator.geolocation.getCurrentPosition(loc => {
                if (loc.coords) {
                    this.workOrderRequest.longitude = loc.coords.longitude;
                    this.workOrderRequest.latitude = loc.coords.latitude;
                }
            });
        }
        
    }

    submitWorkRequest() {
        console.log(this.workOrderRequest);
        
        this._http.post('/api/WorkOrderRequests/SaveNewWorkOrderRequest', this.workOrderRequest).subscribe(() => this.showSuccessMessage());
    }

    showSuccessMessage() {
        this._notifications.open('Request Submitted Successfully',undefined, {
            duration: 2000
        });
    }


}
