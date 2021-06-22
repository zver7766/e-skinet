import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs';
import { map } from 'rxjs/operators';
import { environment } from 'src/environments/environment';
import { IBasket } from '../shared/models/basket';

@Injectable({
  providedIn: 'root'
})
export class BasketService {
  baseUrl = environment.apiUrl;
  private basketSource = new BehaviorSubject<IBasket>(null);
  basket$ = this.basketSource.asObservable();

  constructor(private hhtp: HttpClient) { }

  getBasket(id: string) {
    return this.hhtp.get(this.baseUrl + 'basket?id=' + id)
      .pipe(
        map((basket: IBasket) => {
          this.basketSource.next(basket);
        })
      );
  }

  setBasket(basket: IBasket) {
    return this.hhtp.post(this.baseUrl + 'basket', basket).subscribe((response: IBasket) => {
      this.basketSource.next(response);
    }, error => {
      console.log(error);
    })
  }

  getCurrentBasketValue() {
    this.basketSource.value;
  }
}
