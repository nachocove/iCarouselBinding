all:
	make -C iCarouselLib
	make -C iCarouselBinding
	make -C Demo

clean:
	make -C iCarouselLib clean
	make -C iCarouselBinding clean
	make -C Demo clean
