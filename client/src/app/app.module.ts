import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';

// This is responsible for loading the angluar application
//EACH ANGULAR APPLICATION NEEDS AT LEAST ONE MODULE
@NgModule({
  declarations: [
    AppComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule
  ],
  providers: [],
  //ANGULAR MODULE IS RESPONSBILE FOR BOOTSTRAPING OUR APP COMPONENT, WHICH IS THE ENTRY P0INT TO OUR APPLICATION 
  bootstrap: [AppComponent]
})
export class AppModule { }
