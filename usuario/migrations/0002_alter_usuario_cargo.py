# Generated by Django 4.1 on 2022-08-19 02:28

from django.db import migrations, models
import django.db.models.deletion


class Migration(migrations.Migration):

    dependencies = [
        ('cargo', '0001_initial'),
        ('usuario', '0001_initial'),
    ]

    operations = [
        migrations.AlterField(
            model_name='usuario',
            name='cargo',
            field=models.ForeignKey(null=True, on_delete=django.db.models.deletion.CASCADE, to='cargo.cargo'),
        ),
    ]