// import {ErrorHandler} from '@angular/core';

// import * as Elmahio from 'elmah.io.javascript';

// export class ElmahIoErrorHandler implements ErrorHandler {
//   logger: any;
//   constructor() {
//     this.logger = new Elmahio({
//         apiKey: '87a03e9e26a74d6fa983f9de3a9c8776',
//         logId: 'bd8c1453-5792-461b-8021-5bcc8eb338df',
//     });
//   }
//   handleError(error) {
//     if (error && error.message) {
//       this.logger.error(error.message, error);
//     } else {
//       this.logger.error('Error in application', error);
//     }
//   }
// }