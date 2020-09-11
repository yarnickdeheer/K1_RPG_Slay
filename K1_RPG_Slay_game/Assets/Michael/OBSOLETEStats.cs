public class OBSOLETEStats
{
	//Player stats
	int _level;
	int _vit;
	int _str;
	int _dex;

	//Enemy stats
	int _enemyLevel;

	//Weapon stats
	int _baseDamage;
	int _strScaling;
	int _dexScaling;

	//Armor stats
	int _weight;
	int _resistance;

	//Needed for damage formulas (probably not needed in this class but for now eh)
	int _totalDamage;
	int _damage;
	int _strTotalScaling;
	int _dexTotalScaling;

	//Update stats
	int _newHealth;
	int _newLevel;
	int _newXp;

	/*
	
	Damage formulas:
	_strDamage = 1 * _str * _strScaling;
	_dexDamage = 1 * _dex * _dexScaling;

	_damage = _baseDamage + _strDamage + _dexDamage;
	_totalDamage = _damage - _resistance;
	_newHealth = _totalHealth - _totalDamage;

	Stat formulas:
	_totalHealth = 10 + 2 * _vit;
	_weightLimit = 20 + 2 * _str;
	_movePoints = Mathf.Round(5 + _dex/5 - (_weight - _weightLimit) / 10)

	I don't know if it will be needed in here but experience formulas
	_gainedXp = _enemyLevel * 10;
	int xp;
	for (int i = _level; i--; i <= 0)
	{
		xp += i * 12;
	}
	_newLevel = Mathf.Floor((_gainedXp + xp) / 12);
	_newXp = 12 * ((_gainedXp + xp) / 12 - Mathf.Floor((_gainedXp + xp) / 12));
	
	*/
}