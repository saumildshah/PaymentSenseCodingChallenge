import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { CountryModel } from '../models/country.model';
import { CountryApiService } from '../services/country-api.service';

@Component({
  selector: 'country-detail',
  templateUrl: './country-detail.component.html',
  styleUrls: ['./country-detail.component.scss']
})
export class CountryDetailComponent {

  public country: CountryModel;


  constructor(private countryService: CountryApiService,private router: Router) {
    var state =  this.router.getCurrentNavigation().extras.state;
    if (state)
      this.country = state.data as CountryModel;
    
  }


}
