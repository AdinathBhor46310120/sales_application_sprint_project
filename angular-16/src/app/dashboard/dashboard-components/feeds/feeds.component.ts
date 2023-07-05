

import { Component } from '@angular/core';
import { Router } from '@angular/router';

import { Feeds, Feed } from './feeds-data';

@Component({
  selector: 'app-feeds',
  templateUrl: './feeds.component.html',
})
export class FeedsComponent {
  feeds: Feed[];

  constructor(private router: Router) {
    this.feeds = Feeds;
  }

  // navigateTo(feed: Feed): void {
  //   if (feed.icon === 'bi bi-bell') {
  //     this.router.navigateByUrl('/badges');
  //   }
  // }


  navigateTo(){
      this.router.navigateByUrl('/badges');
  }
}
