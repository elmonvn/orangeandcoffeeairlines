import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HomeComponent } from './home/home.component';
import { SignUpComponent } from './sign-up/sign-up.component';
import { LoginComponent } from './login/login.component';
import { ProfileComponent } from './profile/profile.component';
import { SearchFlightsComponent } from './search-flights/search-flights.component';
import { PaymentComponent } from './payment/payment.component';
import { ShareFlightComponent } from './share-flight/share-flight.component';
import { MainMenuComponent } from './main-menu/main-menu.component';
import { LayoutModule } from '@angular/cdk/layout';
import { MatToolbarModule } from '@angular/material/toolbar';
import { MatButtonModule } from '@angular/material/button';
import { MatSidenavModule } from '@angular/material/sidenav';
import { MatIconModule } from '@angular/material/icon';
import { MatListModule } from '@angular/material/list';
import { MatTableModule } from '@angular/material/table';

@NgModule({
  declarations: [
    HomeComponent,
    SignUpComponent,
    LoginComponent,
    ProfileComponent,
    SearchFlightsComponent,
    PaymentComponent,
    ShareFlightComponent,
    MainMenuComponent
  ],
  exports: [HomeComponent, MainMenuComponent],
  imports: [
    CommonModule,
    LayoutModule,
    MatToolbarModule,
    MatButtonModule,
    MatSidenavModule,
    MatIconModule,
    MatListModule,
    MatTableModule
  ]
})
export class PagesModule {}
