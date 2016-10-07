//
//  ShareiOS.m
//
//
//  Created by Umair Sheikh on 22/03/2016.
//
//
#import <Social/Social.h>
@implementation ViewController : UIViewController
-(void) GeneralShareMethodWith: (const char *) shareMessage
{
    NSString *message = [NSString stringWithUTF8String:shareMessage];
    NSArray *postItems = @[message];
    UIActivityViewController *activityVc = [[UIActivityViewController alloc] initWithActivityItems:postItems applicationActivities:nil];
    if (UI_USER_INTERFACE_IDIOM() == UIUserInterfaceIdiomPad && [activityVc respondsToSelector:@selector(popoverPresentationController)] ) {
        UIPopoverController *popup = [[UIPopoverController alloc] initWithContentViewController:activityVc];
        [popup presentPopoverFromRect:CGRectMake(self.view.frame.size.width/2, self.view.frame.size.height/4, 0, 0)
                               inView:[UIApplication sharedApplication].keyWindow.rootViewController.view permittedArrowDirections:UIPopoverArrowDirectionAny animated:YES];
    }
    else
        [[UIApplication sharedApplication].keyWindow.rootViewController presentViewController:activityVc animated:YES completion:nil];
}
-(void) GeneralShareMethodWith: (const char *) path Message : (const char *) shareMessage Link: (const char *) link
{
    NSString *imagePath = [NSString stringWithUTF8String:path];
    // UIImage *image = [UIImage imageNamed:imagePath];
    UIImage *image = [UIImage imageWithContentsOfFile:imagePath];
    NSString *message = [NSString stringWithUTF8String:shareMessage];
    NSURL *url = [NSURL URLWithString:[NSString stringWithUTF8String:link]];
    NSArray *postItems = @[url,message,image];
    UIActivityViewController *activityVc = [[UIActivityViewController alloc]initWithActivityItems:postItems applicationActivities:nil];
    if ( UI_USER_INTERFACE_IDIOM() == UIUserInterfaceIdiomPad && [activityVc respondsToSelector:@selector(popoverPresentationController)] ) {
        UIPopoverController *popup = [[UIPopoverController alloc] initWithContentViewController:activityVc];
        [popup presentPopoverFromRect:CGRectMake(self.view.frame.size.width/2, self.view.frame.size.height/4, 0, 0)
                               inView:[UIApplication sharedApplication].keyWindow.rootViewController.view permittedArrowDirections:UIPopoverArrowDirectionAny animated:YES];
    }
    else
        [[UIApplication sharedApplication].keyWindow.rootViewController presentViewController:activityVc animated:YES completion:nil];
}


extern "C"{
    void ShareImageToFacebook_iOS(const char * path, const char * message, const char * link){
        ViewController *vc = [[ViewController alloc] init];
        [vc GeneralShareMethodWith:path Message:message Link:link];
    }
}
@end
