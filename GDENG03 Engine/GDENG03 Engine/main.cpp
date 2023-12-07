// GDENG03 XX22
// Mayuga, David Rex C.
// [FE] Final Exam Programming Challenge

#include"AppWindow.h"

int main() {
	AppWindow game;

	if (game.initialize()) {
		while (game.isRunning()) {
			game.broadcast();
		}
	}

	return 0;
}