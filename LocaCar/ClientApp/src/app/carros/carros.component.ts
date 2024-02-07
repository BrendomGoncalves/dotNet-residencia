import { Component } from '@angular/core';

@Component({
  selector: 'app-carros-component',
  templateUrl: './carros.component.html'
})
export class CarrosComponent {
  public currentCount = 0;

  public incrementCounter() {
    this.currentCount++;
  }
}
