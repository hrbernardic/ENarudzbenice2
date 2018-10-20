import { trigger, sequence, state, animate, transition, style } from '@angular/animations';

export const rowAnimation = trigger('rowAnimation', [
  transition('void => *', [
    style({ opacity: '0' }),
    sequence([
      // animate('.18s ease', style({ opacity: '0', height: '30px' })),
      animate('.38s ease', style({ opacity: 1 }))
    ])
  ])
]);

//   animate('.35s ease', style({ height: '*', opacity: '.2', transform: 'translateX(0)', 'box-shadow': 'none' })),
//   animate('.35s ease', style({ height: '*', opacity: 1, transform: 'translateX(0)' }))
