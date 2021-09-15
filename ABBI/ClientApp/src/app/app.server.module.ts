import { HttpClient } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { ServerModule } from '@angular/platform-server';
import { ModuleMapLoaderModule } from '@nguniversal/module-map-ngfactory-loader';
import { Observable } from 'rxjs';
import { AppComponent } from './app.component';
import { AppModule } from './app.module';

@NgModule({
  imports: [AppModule, ServerModule, ModuleMapLoaderModule],
  bootstrap: [AppComponent]
})
export class AppServerModule {
  constructor(private http: HttpClient) { }
  readonly APIUrl = "https://localhost:44374/api/v1";

  getProdList(): Observable<any[]> {
    return this.http.get<any>(this.APIUrl + '/Product');
  }

}
