//
//  PhotoManger.m
//  Unity-iPhone
//
//  Created by TomHsiao on 2019/5/29.
//

#import "PhotoManager.h"

@implementation PhotoManager
- ( void ) imageSaved: ( UIImage *) image didFinishSavingWithError:( NSError *)error
          contextInfo: ( void *) contextInfo
{
    NSLog(@"儲存結束");
    if (error != nil) {
        NSLog(@"有錯誤");
    }
}
void  _TakeAPictureBtn(char *readAddr)
{
    NSString *strReadAddr = [NSString stringWithUTF8String:readAddr];
    UIImage *img = [UIImage imageWithContentsOfFile:strReadAddr];
    NSLog(@"%@",[NSString stringWithFormat:@"w:%f, h:%f", img.size.width, img.size.height]);
    NSLog(@"%@",[NSString stringWithFormat:@"%s",readAddr ]);
    PhotoManager *instance = [[PhotoManager alloc]init];
    UIImageWriteToSavedPhotosAlbum(img, instance,
                                   @selector(imageSaved:didFinishSavingWithError:contextInfo:), nil);
   }
@end
