import { Component, ViewChild } from '@angular/core';
import { CountryApiService } from '../services/country-api.service';
import { CountryModel } from '../models/country.model';
import { MatPaginator, MatTableDataSource  } from '@angular/material';


@Component({
  selector: 'country-list',
  templateUrl: './country-list.component.html',
  styleUrls: ['./country-list.component.scss']
})
export class CountryListComponent{
  displayedColumns: string[] = ['name', 'flag'];
  countriesDataSource: MatTableDataSource<CountryModel>;
  @ViewChild(MatPaginator, { static: false }) paginator: MatPaginator;

    public title = 'Country List!';
  public countries: CountryModel[] = [];
    
  constructor(private countryService: CountryApiService) {
    this.getCountries();
  }

  private getCountries() {

   
    
    this.countryService.getCountries().subscribe(c => {
      this.countries =
        c.map(country => new CountryModel(
            country.name,
            country.flag,
            country.region,
            country.subregion,
          country.population,
          country.capital,
          country.timezones,
          country.currencies,
          country.languages,
          country.borders
        ));
      this.countriesDataSource = new MatTableDataSource(this.countries);
      this.countriesDataSource.paginator = this.paginator;
    });
    
  }

}
