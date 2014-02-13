all:
	make -C iCarouselLib
	make -C iCarouselBinding

clean:
	make -C iCarouselLib clean
	make -C iCarouselBinding clean
