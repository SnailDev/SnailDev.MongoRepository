Repository abstraction layer on top of Official MongoDB C# driver

#### The difference between Official MongoDB C# driver version 1.x and 2.x
![](https://i.imgur.com/xXPCSiX.png)

#### How to use? Here some examples
**Insert**
--- --- --- ---
	User user = new User();
	user.Name = "aa";
	await userRep.InsertAsync(user);
**InsertBatch**
--- --- --- ---
	List<User> userList = new List<User>();
	for (var i = 0; i < 5; i++)
	{
	    User user = new User();
	    user.Name = new Random(1).ToString();
	    userList.Add(user);
	}
	await userRep.InsertBatchAsync(userList);

**Update**
--- --- --- ---
	await userRep.UpdateOneAsync(x => x.ID == 4, u => u.Set(nameof(User.CreateTime), DateTime.Now));
	await userRep.UpdateOneAsync(x => x.ID == 4, u => u.Set(x => x.CreateTime, DateTime.Now));

	User user = new User();
	user.Age += 1;
	user.CreateTime = DateTime.Now;
	user.Name = "zzz";
	await userRep.UpdateOneAsync(x => x.Name == "xx", user, true);

	var update = UserRepAsync.Update.Set(nameof(User.CreateTime), DateTime.Now);
	await userRep.UpdateManyAsync(x => x.Name == "cc", update);
**FindOneAndUpdate**
--- --- --- ---
	User user = await userRep.GetAsync(15);
	user = await userRep.FindOneAndUpdateAsync(filterExp: x => x.ID == user.ID, updateEntity: user, isUpsert: false);
**Get**
--- --- --- ---
	user = await userRep.GetAsync(1);
	user = await userRep.GetAsync(x => x.Name == "aa");
	user = await userRep.GetAsync(x => x.Name == "aa", x => new { x.Name });
	user = await userRep.GetAsync(x => x.Name == "aa" && x.CreateTime > DateTime.Parse("2015/10/20"));
	
	var filter = UserRepAsync.Filter.Eq(x => x.Name, "aa") & UserRepAsync.Filter.Eq(x => x.ID, 123);
	UserRepAsync.Sort.Descending("_id");
	user = await userRep.GetAsync(Builders<User>.Filter.Eq("Name", "aa"), null, Builders<User>.Sort.Descending("_id"));
