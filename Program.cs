int playerHp = 50;
int enemyHp = 50;
Random dice = new Random();
int potion = 3;
int coldDown = 0;
string[] skills = {"Soco-Foguete", "14", "Espada de Chamas", "10"};

do {
     Thread.Sleep(3000);
     Console.Clear();
     
    Console.WriteLine("-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=");
    Console.WriteLine($"Você atualmente tem {playerHp} de vida.");
    Console.WriteLine($"Seu inimigo possui {enemyHp} de vida");
    Console.WriteLine("-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=");
    Console.WriteLine("O que deseja fazer?");
    Console.WriteLine("[1] - Atacar");
    Console.WriteLine("[2] - Defender");
    Console.WriteLine("[3] - Fugir");
    Console.WriteLine("[4] - Itens");
    Console.WriteLine("[5] - Habilidades");
    Console.WriteLine("-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=");

    int roll = dice.Next(1, 8);
    int rollEnemy = dice.Next(3, 9);
    

        while (true){
            string input = Console.ReadLine();  
            if (input == "1" || input == "2" || input == "3" || input == "4" || input == "5"){
                switch (input){
                    case "1":
                    Console.WriteLine();
                    Console.WriteLine("-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*");
                    Console.WriteLine("Você balança sua espada.");
                    if (roll < 3) {Console.WriteLine("Seu ataque foi pouco eficaz.");}
                    Console.WriteLine($"Seu inimigo perdeu {roll} pontos de vida!");
                    Console.WriteLine($"Você foi atacado e perdeu {rollEnemy} de HP!");
                    Console.WriteLine("-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*");
                    Console.WriteLine();
                        if (coldDown > 0){
                                coldDown--;
                            }
                    enemyHp -= roll;
                    playerHp -= rollEnemy;
                        break;

                    case "2":
                    Console.WriteLine();
                    Console.WriteLine("-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*");
                    Console.WriteLine("Você se defendeu, reduzindo metade do dano recebido!");
                    Console.WriteLine($"Você foi atacado e perdeu {rollEnemy/2} de HP!");
                                    if (coldDown > 0){
                        coldDown--;
                    }
                    Console.WriteLine("-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*");
                    Console.WriteLine();
                    playerHp -= rollEnemy/2;
                        break;

                    case "3":
                    Console.WriteLine();
                    Console.WriteLine("-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*");
                    Console.WriteLine("Você tenta fugir");
                    if (roll <= 2) {
                        Console.WriteLine("Você obteve êxito na sua fuga.");
                        enemyHp = 0;
                    } else {
                        Console.WriteLine("Sua fuga falhou.");
                        Console.WriteLine($"Você foi atacado e perdeu {rollEnemy} de HP!");
                        playerHp -= rollEnemy;
                    }
                    Console.WriteLine("-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*");
                    Console.WriteLine();
                        break;

                    case "4":
                    bool voltar = false;
                    while (!voltar){
                        Console.WriteLine("-------------------------------------");
                        Console.WriteLine($"[{potion}] - Poções");
                        Console.WriteLine("-------------------------------------");
                        Console.WriteLine("[1] - Usar Poção");
                        Console.WriteLine("[2] - Voltar");
                        string inputItem = Console.ReadLine(); 
                        if (inputItem == "1"){
                            if (potion > 0){
                                potion --;
                                
                                playerHp += 10;
                                Console.WriteLine("Você consumiu uma poção de vida, adquirindo 10 de HP!");
                                Console.WriteLine($"Você foi atacado e perdeu {rollEnemy} de HP!");
                                playerHp -= rollEnemy;
                                
                                voltar = true;
                            } else {
                                Console.WriteLine("Você não tem mais poções de vida!");
                            }
                        } else if (inputItem == "2"){
                            voltar = true;
                        } else {
                            Console.WriteLine("Digite um número valido!");
                        }

                    }

                    break;

                    case "5":
                        if (coldDown == 0) {
                            voltar = false;
                            int i = 0;
                            Console.WriteLine("-------------------------------------");
                            for (var id = 0; id
                                < skills.Length;
                                id+=2){
                                i++;
                                Console.WriteLine($"[{i}] = [{skills[id]}]");

                                Console.WriteLine($"Dano = [{skills[id+1]}]");
                            }
                            Console.WriteLine($"[3] - Voltar");
                                Console.WriteLine("-------------------------------------");
                            while(!voltar){
                                Console.WriteLine("Escolha uma habilidade!");
                                string escolherHabilidade = Console.ReadLine();
                                if (escolherHabilidade == "1"){
                                    Console.WriteLine($"Você escolheu {skills[0]} que causa {skills[1]} de dano!");
                                    enemyHp -= int.Parse(skills[1]);
                                    Console.WriteLine($"Você foi atacado e perdeu {rollEnemy} de HP!");
                                    playerHp -= rollEnemy;
                                    coldDown += 3;
                                    break;
                                } else if (escolherHabilidade == "2"){
                                    Console.WriteLine($"Você escolheu {skills[2]} que causa {skills[3]} de dano!");
                                    enemyHp -= int.Parse(skills[3]);
                                    Console.WriteLine($"Você foi atacado e perdeu {rollEnemy} de HP!");
                                    playerHp -= rollEnemy;
                                    coldDown += 3;
                                    break;

                                } else if (escolherHabilidade == "3"){
                                    Console.WriteLine("Você decidiu voltar.");{
                                        voltar = true;
                                    }

                                } else {
                                    Console.WriteLine("Opção inválida!");
                                }
                            } } else {
                    Console.WriteLine("Esta habilidade está em ColdDown no momento.");
                    Console.WriteLine($"Tente novamente em {coldDown} turnos");
                    break;
                            
                    }
                break;
                }
            break;
            } else{
                Console.WriteLine("Número invalido, tente novamente!");
            }
                      
        }


} while (playerHp > 0 && enemyHp > 0);

if (enemyHp > playerHp){
    Console.WriteLine("Derrota. O inimigo venceu.");
} else {
    Console.WriteLine("VITÓRIA! Parabéns!");
}