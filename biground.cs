constructor(data: WaveData) {
    super();
    this._data = data;
    this._rounds = this._data.getRounds();//回合信息，是一个数组,长度代表回合的此时
    this.index = 0;//大回合进行的索引
    ......
}
//检查是否要更新大回合
private checkRound()
{
    if (this._round == null)
    {
        //更新大回合
        this._round = new LoopRound(this._rounds[this.index - 1])
        if (this.index != 1)  
        {
            
            
        }
    }
}
public update(f: number) {
    // console.log("LoopWave:update", this.index);
    if (this.index > this._rounds.length)
    {
        //所有的大回合结束了
        console.log("LoopWave:update round end");
        if (this.checkUnitIdle())
        {
            this.isFinish = true
          }
        else
        {
            if (!this._checkEndIdle)
            {
                BuffManager.getBuffManager().engine.makeUnitIdle();
                this._checkEndIdle = true;
            }
        }
    }
    else
    {
        this.checkRound()
          if (this._round)
        {
            //当前大回合是否开始
            if (!this._round.isStart)
                //开始当前大回合
                this._round.start()
              else
                //更新当前这个大回合
                this._round.update(f)
              if (this._round.isFinish)
            {
                //当前这个大回合完成了
                this._round.onFinish()
                  this._round = null
                  //更新大回合进行的索引
                  this.index = this.index + 1
                  console.log("LoopWave round next:", this.index);
            }
        }
    }

    if (this._isStartEnter)
    {
        if (this._enterTime >= this._waitTime)
        {
            this._unitJumpIn()
              this._enterTime = 0
          }
        this._enterTime += f;
    }
}
