#Beta Builds
* [ ] Update MDVersion to handle previous version
* [X] Update build and/or version numbers in Android & iOS build settings
* [ ] use xARM to test the devices with the highest resolution, smallest & largest height & width, and extreme aspect ratios 16:9 and 4:3
* [X] Test on device
* [o] iOS Build
 * [X] Build in unity
 * [o] Upload in XCode
  * [X] 1) choose "generic iOS device" (don't choose Ipad or any other devices connected or a simulator) 
  * [X] 2) Go to Product --> Archive
  * [ ] 3) it should open the archive in the Organizer. Click "validate" and then "Upload to App Store". 
 * [ ] When you get the first email ("processed"), go to iTunesConnect and
  * [ ] update compliance info at iTunesConnect
  * [ ] Check "Test Information" under IOSBuilds...Test Details in testflight, in the right language -- see Texts below (https://itunesconnect.apple.com/WebObjects/iTunesConnect.woa/ra/ng/app/1296879662/testflight?section=build&subsection=testdetails&id=24416006)
  * [ ] Add groups to the build
 * [ ] Check Beta App Description, etc. in Testflight...Test Information
  * https://itunesconnect.apple.com/WebObjects/iTunesConnect.woa/ra/ng/app/1296879662/testflight?section=testinformation
* [ ] Tag version in git
#Release Builds
* [ ] Deploy
 * [ ] Update MDVersion to handle previous version
 * [ ] Update build and/or version numbers in Android & iOS build settings
 * [ ] use xARM to test the devices with the highest resolution, smallest & largest height & width, and extreme aspect ratios 16:9 and 4:3
 * [ ] Ensure that screenshots / video are up to date
  * [ ] Add grid button screenshots for small devices
 * [ ] Test on device by changing bundle id to einmaleins2
 * [ ] Change bundle id back to einmaleins
 * [ ] Ensure that Datenschutzerklärung is still true (e.g. if you add tracking or cross-branding). Model is https://www.carlsen.de/datenschutzerklaerung-apps 
 * [ ] iOS Build
  * [ ] Build in unity
  * [ ] Upload in XCode
   * [ ] 1) choose "generic iOS device" (don't choose Ipad or any other devices connected or a simulator) 
   * [ ] 2) Go to Product --> Archive
   * [ ] 3) it should open the archive in the Organizer. Click "validate" and then "Upload to App Store". 
  * [ ] When you get the first email ("processed"), go to iTunesConnect and
   * [ ] update compliance info at iTunesConnect
   * [ ] Check "Test Information" under IOSBuilds...Test Details in testflight, in the right language -- see Texts below (https://itunesconnect.apple.com/WebObjects/iTunesConnect.woa/ra/ng/app/1296879662/testflight?section=build&subsection=testdetails&id=24416006)
   * [ ] Add groups to the build
  * [ ] Check Beta App Description, etc. in Testflight...Test Information
   * https://itunesconnect.apple.com/WebObjects/iTunesConnect.woa/ra/ng/app/1296879662/testflight?section=testinformation
  * [ ] Update Noun Project credits on store page 
 * [ ] Android Build
  * [ ] Enter passwords (build settings... publishing settings...keystore password) before building in Unity
  * [ ] New test: https://support.google.com/googleplay/android-developer/answer/3131213?hl=en
  * [ ] New release: https://support.google.com/googleplay/android-developer/answer/7159011
   * Play Console...Release Management... New Release...Browse Files
  * [ ] https://play.google.com/about/families/designed-for-families/program-requirements/  
  * [ ] update version number (?)
  * [ ] Update Noun Project credits on store page 
 * [ ] Tag version in git
