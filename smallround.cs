constructor(data: Round) {
    super();
    this._data = data;
    this._index = 0     //attack序列号
        this._attack = null  //每一次攻击的实例
        this._buff = null
        this._attackIndex = 0   //execute的attack序列号
}
public checkAttack()
{
    if (this._attack == null)
    {
        let attackData = this._data.attacks[this._index - 1];
        // else if (attackData.isHistory) {
        //     this._attack = new LoopOneAttackhistory(attackData, this._index);
        // }
        else
        {
            this._attack = new LoopOneAttack(attackData, this._index);
        }
    }
}

public update(f: number) {
    // console.log("LoopRpund update:", this.index, this.data.attacks.length);
    if (this._index > this._data.attacks.length)
    {
        //大回合所有攻击结束
        this.isFinish = true;
    }
    else
    {
        //判断是否要进入新的攻击
        this.checkAttack();
        if (this._attack)
        {
            if (this._attack.isFinish)
            {
                //本轮攻击结束 清除本轮攻击数据
                this._attack.clear();

                this._attack = null;
                //攻击索引+1 准备进入下一次攻击
                this._index += 1;
                console.log("LoopRound attack next:", this._index);
            }
            else
            {
                if (this._attack.isExecute())
                {
                    this._attack.execute();
                    this._attackIndex += 1;
                }
            }
        }
    }
}
