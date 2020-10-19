import { Component } from '@angular/core';
import { BreakpointObserver, Breakpoints } from '@angular/cdk/layout';
import { Observable } from 'rxjs';
import { map, shareReplay } from 'rxjs/operators';
import { FlightsService } from '../../core/services/flights.service';
import { resolveSanitizationFn } from '@angular/compiler/src/render3/view/template';

@Component({
  selector: 'app-main-menu',
  templateUrl: './main-menu.component.html',
  styleUrls: ['./main-menu.component.scss']
})
export class MainMenuComponent {
  isHandset$: Observable<boolean> = this.breakpointObserver
    .observe(Breakpoints.Handset)
    .pipe(
      map((result) => result.matches),
      shareReplay()
    );

  constructor(
    private breakpointObserver: BreakpointObserver,
    private _flightsService: FlightsService
  ) {}

  flights: unknown;

  ngOnInit() {
    this._flightsService
      .searchFlights('REC', 'GRU', '2020-11-10', '2020-11-20')
      .subscribe(
        (res) => {
          this.flights = res.content.result;
          console.log(JSON.parse(res.content.result));
        },
        (error) => {
          console.error(error);
        }
      );
  }
}
