import { trigger, sequence, state, animate, transition, style } from '@angular/animations';

export const rowAnimation = trigger('rowAnimation', [
  transition('void => *', [
    style({ height: '*', opacity: '0', transform: 'translateX(-200px)', 'box-shadow': 'none' }),
    sequence([
      animate('.35s ease', style({ height: '*', opacity: '.2', transform: 'translateX(0)', 'box-shadow': 'none' })),
      animate('.35s ease', style({ height: '*', opacity: 1, transform: 'translateX(0)' }))
    ])
  ])
]);

//   animate('.35s ease', style({ height: '*', opacity: '.2', transform: 'translateX(0)', 'box-shadow': 'none' })),
//   animate('.35s ease', style({ height: '*', opacity: 1, transform: 'translateX(0)' }))
