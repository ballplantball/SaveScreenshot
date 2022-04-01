//
//  PhotoManger.h
//  Unity-iPhone
//
//  Created by 李俊逸 on 2019/5/29.
//

#ifndef PhotoManger_h
#define PhotoManger_h


#endif /* PhotoManger_h */
#import <Foundation/Foundation.h>
#import <UIKit/UIKit.h>
@interface PhotoManager : NSObject
- ( void ) imageSaved: ( UIImage *) image didFinishSavingWithError:( NSError *)error
          contextInfo: ( void *) contextInfo;
@end
