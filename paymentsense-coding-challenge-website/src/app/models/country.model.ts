import { CurrencyModel } from "./currency.model";
import { LanguageModel } from "./language.model";

export class CountryModel {
  public name: string;
  public flag: string;
  public region: string;
  public subregion: string;
  public population: number;
  public capital: string;
  public timezones: string[];
  public currencies: CurrencyModel[];
  public languages: LanguageModel[];
  public borders: string[];

  constructor(name: string, flag: string, region: string,
    subregion: string, population: number, capital: string,
    timezones: string[], currencies: CurrencyModel[], languages: LanguageModel[],
    borders: string[]
  ) {
   
    this.name = name;
    this.flag = flag;
    this.region = region;
    this.subregion = subregion;
    this.population = population;
    this.capital = capital;
    this.timezones = timezones;
    this.currencies = currencies;
    this.languages = languages;
    this.borders = borders;

    //console.log(timezones);
    //console.log(currencies);
    //console.log(languages);
    //console.log(borders);
  }
}
