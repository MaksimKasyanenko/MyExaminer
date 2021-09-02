class TestingTimer{
	dispElement: HTMLDivElement;
	timeLeft: number;
	constructor(dispElement){
		this.dispElement = dispElement;
		this.timeLeft = 0;
	}
	get time(): number{
		return this.timeLeft;
	}
	set time(val: number) {
		this.timeLeft = val < 0 ? 0 : val;
		this._updateDisp();
	}
	get finished(): boolean{
		return this.timeLeft<=0;
	}
	start(){
		setTimeout(()=>this.tick(), 1000);
	}
	tick(){
		this.time -= 1;
		this._updateDisp();
		if(this.finished)return;
		setTimeout(()=>this.tick(), 1000);
	}
	_updateDisp() {
		let min = Math.floor(this.timeLeft / 60);
		let sec = this.timeLeft % 60;
		this.dispElement.textContent = `${min<10?'0':''}${min} : ${sec<10?'0':''}${sec}`;
    }
}