
XBUILD=xcodebuild
PROJECT_ROOT=.
PROJECT=$(PROJECT_ROOT)/iCarouselLib.xcodeproj
TARGET=iCarouselLib

all: libiCarouselLibSDK.a

libiCarouselLib-i386.a:
	$(XBUILD) -project $(PROJECT) -target $(TARGET) -sdk iphonesimulator -configuration Release clean build
	-mv $(PROJECT_ROOT)/build/Release-iphonesimulator/lib$(TARGET).a $@

libiCarouselLib-armv7.a:
	$(XBUILD) -project $(PROJECT) -target $(TARGET) -sdk iphoneos -arch armv7 -configuration Release clean build
	-mv $(PROJECT_ROOT)/build/Release-iphoneos/lib$(TARGET).a $@

libiCarouselLibSDK.a: libiCarouselLib-i386.a libiCarouselLib-armv7.a
	lipo -create -output $@ $^

clean:
	-rm -fr build
	-rm -f *.a *.dll
	-rm -fr ./iCarouselLib.xcodeproj/project.xcworkspace
	-rm -fr ./iCarouselLib.xcodeproj/xcuserdata
